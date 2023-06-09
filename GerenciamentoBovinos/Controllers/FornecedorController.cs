﻿using GerenciamentoBovinos.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GerenciamentoBovinos.Controllers
{
    public class FornecedorController : Controller
    {
        private GerenciamentoContext db = new GerenciamentoContext();

        // GET: Fornecedor
        public ActionResult Index(string retorno = null)
        {
            ViewBag.Retorno = retorno;
            return View(db.Fornecedores.ToList());
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InscricaoEstadual,Nome,Email,Telefone,Rua,Numero,Estado,Cidade,Cep,Complemento,CPFCNPJ")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedores.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InscricaoEstadual,Nome,Email,Telefone,Rua,Numero,Estado,Cidade,Cep,Complemento,CPFCNPJ")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(long? id)
        {
            Fornecedor fornecedor = db.Fornecedores.Find(id);

            List<Bovino> listaBovinos = db.Bovinos.Where(x => x.FornecedorId == id).ToList();
            List<Produto> listaProdutos = db.Produtos.Where(x => x.FornecedorId == id).ToList();

            if (listaBovinos != null && listaBovinos.Count > 0)
            {
                return RedirectToAction("Index", new { retorno = "Este Fornecedor esta relacionado a algum bovino cadastrado!" });
            }
            else if (listaProdutos != null && listaProdutos.Count > 0)
            {
                return RedirectToAction("Index", new { retorno = "Este Fornecedor esta relacionado a algum produto cadastrado!" });
            }

            if (fornecedor != null)
            {
                db.Fornecedores.Remove(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return new HttpNotFoundResult();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}